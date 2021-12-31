using laba_1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba_1.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        /// <summary>         
        /// Количество объектов в корзине         
        /// </summary> 
        public int Count
        {
            get
            { return Items.Sum(item => item.Value.Quantity); }
        }
        /// <summary>         
        /// дальность        
        /// </summary> 
        public int detection
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.Ajax.detection);
            }
        }
        /// <summary>         
        /// Добавление в корзину        
        /// </summary>         
        /// <param name="ajax">добавляемый объект</param> 
        public virtual void AddToCart(Ajax ajax)
        {
            // если объект есть в корзине
            // то увеличить количество   
            if (Items.ContainsKey(ajax.DivicesID))
                Items[ajax.DivicesID].Quantity++;
            // иначе - добавить объект в корзину 
            else
                Items.Add(ajax.DivicesID, new CartItem
                {
                    Ajax = ajax,
                    Quantity = 1
                });
        }
        /// <summary>         
        /// Удалить объект из корзины         
        /// </summary>         
        /// <param name="id">id удаляемого объекта</param> 
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        /// <summary>         
        /// Очистить корзину         
        /// </summary> 
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
    /// <summary> 
    /// Класс описывает одну позицию в корзине    
    /// </summary> 
    public class CartItem
    {
        public Ajax Ajax { get; set; }
        public int Quantity { get; set; }
    }
}

